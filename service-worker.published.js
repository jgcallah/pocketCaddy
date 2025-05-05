// Basic Blazor PWA offline caching
self.assetsManifest = {
  assets: [
    // This will be auto-injected at publish by Blazor
  ],
};

self.addEventListener("install", () => self.skipWaiting());
self.addEventListener("activate", () => self.clients.claim());

self.addEventListener("fetch", (event) => {
  event.respondWith(
    caches
      .match(event.request)
      .then((response) => response || fetch(event.request))
  );
});
