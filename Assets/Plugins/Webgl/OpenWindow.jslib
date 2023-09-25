var OpenWindowPlugin = {
    openWindow: function(link)
    {
		var url = Pointer_stringify(link);
		document.onmouseup = function()
		{
			function getFormattedTimestamp() {
				return new Date(Date.now() - 60000 * new Date().getTimezoneOffset()).toISOString().replace(/\..*/g, '').replace(/T/g, ' ').replace(/:/g, '-');
			}
	 
			var button = document.createElement("a");
			button.setAttribute("href", url);
			button.setAttribute("download", "Screenshot " + getFormattedTimestamp() + ".png");
			button.style.display = "none";
			document.body.appendChild(button);
			button.click();
			document.body.removeChild(button);
			document.onmouseup = null;
		}

		// Capture Enter key press and check for mouse event
        document.onkeyup = function(event)
        {
			if ((event.key === "Enter" || event.keyCode === 13) && event.type !== "mouseup")
            {
				function getFormattedTimestamp() {
					return new Date(Date.now() - 60000 * new Date().getTimezoneOffset()).toISOString().replace(/\..*/g, '').replace(/T/g, ' ').replace(/:/g, '-');
				}
		 
		 
				var button = document.createElement("a");
				button.setAttribute("href", url);
				button.setAttribute("download", "Screenshot " + getFormattedTimestamp() + ".png");
				button.style.display = "none";
				document.body.appendChild(button);
				button.click();
				document.body.removeChild(button);
				document.onmouseup = null;
			}
        }
	}
};

mergeInto(LibraryManager.library, OpenWindowPlugin);
