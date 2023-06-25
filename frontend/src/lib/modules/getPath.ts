import { setPageStore } from "$lib/stores/pageStore";

// Gets the route of the current page.
export function getPath() {
	return window.location.pathname as string;
}

// Sets the path in pageStore
export function setPath() {
	setPageStore(getPath());
}
