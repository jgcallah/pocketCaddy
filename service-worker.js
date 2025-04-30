const CACHE_NAME = "golf-app-cache-v1";
const BASE_PATH = "/YOUR-REPO-NAME/"; // ← Change this to your repo name
const OFFLINE_URL = BASE_PATH + "offline.html";

// Files to cache (adjust based on your app's needs)
const PRECACHE_URLS = [
  BASE_PATH,
  BASE_PATH + "index.html",
  BASE_PATH + "css/app.css",
  BASE_PATH + "js/app.js",
  BASE_PATH + "_framework/blazor.webassembly.js",
  BASE_PATH + "_framework/wasm/dotnet.wasm",
  BASE_PATH + "manifest.json",
  BASE_PATH + "icons/ios/192.png",
];

self.addEventListener("install", (event) => {
  event.waitUntil(
    caches
      .open(CACHE_NAME)
      .then((cache) => {
        console.log("[ServiceWorker] Pre-caching offline page");
        return cache.addAll(PRECACHE_URLS);
      })
      .then(() => self.skipWaiting())
  );
});

self.addEventListener("activate", (event) => {
  event.waitUntil(
    caches
      .keys()
      .then((cacheNames) => {
        return Promise.all(
          cacheNames.map((cacheName) => {
            if (cacheName !== CACHE_NAME) {
              console.log("[ServiceWorker] Removing old cache", cacheName);
              return caches.delete(cacheName);
            }
          })
        );
      })
      .then(() => self.clients.claim())
  );
});

self.addEventListener("fetch", (event) => {
  // Skip non-GET requests
  if (event.request.method !== "GET") return;

  // Handle navigation requests specially for GitHub Pages
  if (event.request.mode === "navigate") {
    event.respondWith(
      fetch(event.request).catch(() => {
        return caches.match(BASE_PATH + "index.html");
      })
    );
    return;
  }

  // For all other requests, try cache first
  event.respondWith(
    caches.match(event.request).then((response) => {
      return (
        response ||
        fetch(event.request)
          .then((response) => {
            // Cache new responses for future use
            if (
              event.request.url.startsWith("http") &&
              !event.request.url.includes("sockjs-node")
            ) {
              const responseToCache = response.clone();
              caches
                .open(CACHE_NAME)
                .then((cache) => cache.put(event.request, responseToCache));
            }
            return response;
          })
          .catch(() => {
            // Special handling for Blazor framework files
            if (event.request.url.includes("_framework")) {
              return caches.match(
                event.request.url.replace(location.origin, BASE_PATH)
              );
            }
            return caches.match(OFFLINE_URL);
          })
      );
    })
  );
});
