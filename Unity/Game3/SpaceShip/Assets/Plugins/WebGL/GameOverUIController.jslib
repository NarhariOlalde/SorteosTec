mergeInto(LibraryManager.library, {
  getCookie: function (namePtr) {
    var name = UTF8ToString(namePtr);
    var value = "; " + document.cookie;
    var parts = value.split("; " + name + "=");
    if (parts.length == 2) {
        var cookieValue = parts.pop().split(";").shift();
        console.log("Found cookie: " + cookieValue);
        return allocate(intArrayFromString(cookieValue), 'i8', ALLOC_NORMAL);
    }
    console.log("Cookie not found");
    return 0; // Return 0 to indicate null pointer
  }
});
