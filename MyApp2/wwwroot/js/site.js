let switchMode = document.getElementById("switchMode");

switchMode.onclick = function () {
	let theme = document.getElementById("theme")

	if (theme.getAttribute("href") = "~/css/light-mode.css") {
		theme.href = "~/css/dark-mode.css"
	} else {
		theme.href = "~/css/light-mode.css"
	}
}
