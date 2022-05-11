// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function injectHeadScript(source, id, asContent) {
    if (source.Length == 0) {
        console.error("Invalid source URL");
        return;
    }

    var tag = document.getElementById(id) || document.createElement('script');
    tag.id = id;

    if (asContent) {
        tag.innerHTML = source;
    } else {
        tag.src = source;
    }

    tag.type = "text/javascript";

    tag.onload = function () {
        console.log("Script loaded successfully");
    }

    tag.onerror = function () {
        console.error("Failed to load script");
    }

    document.head.appendChild(tag);
}
