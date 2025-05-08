using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;
using PocketCaddy.Model; // Assuming your UserData class is in this namespace

namespace PocketCaddy.Services
{
    public class PocketCaddyStateService
    {
        private readonly IJSRuntime _js;
        private const string LocalStorageKey = "PocketCaddyState";

        public PocketCaddyStateService(IJSRuntime js)
        {
            _js = js;
        }

        private UserData _data;

        public async Task SaveStateAsync(UserData state)
        {
            try
            {
                _data = state;
                var serializedState = JsonSerializer.Serialize(state);
                await _js.InvokeVoidAsync("localStorage.setItem", LocalStorageKey, serializedState);
            }
            catch (Exception ex)
            {
                // Consider logging the error
                Console.WriteLine($"Error saving UserData to localStorage: {ex.Message}");
            }
        }

        public async Task<UserData?> LoadStateAsync()
        {
            try
            {
                if (_data is null)
                {
                    var serializedState = await _js.InvokeAsync<string?>("localStorage.getItem", LocalStorageKey);
                    if (!string.IsNullOrEmpty(serializedState))
                    {
                        _data = JsonSerializer.Deserialize<UserData>(serializedState);
                    }
                }
            }
            catch (Exception ex)
            {
                // Consider logging the error
                Console.WriteLine($"Error loading UserData from localStorage: {ex.Message}");
                return null; // Or return a default UserData object
            }
            return _data;
        }

        public async Task ClearStateAsync()
        {
            try
            {
                await _js.InvokeVoidAsync("localStorage.removeItem", LocalStorageKey);
            }
            catch (Exception ex)
            {
                // Consider logging the error
                Console.WriteLine($"Error clearing UserData from localStorage: {ex.Message}");
            }
        }

        // Optional: Method to initialize state if nothing is in localStorage
        public async Task<UserData> GetOrCreateStateAsync()
        {
            var loadedState = await LoadStateAsync();
            return loadedState ?? new UserData();
        }
    }
}