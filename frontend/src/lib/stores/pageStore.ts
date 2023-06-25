// This is to get the current page
// to display the active tab on the navbar.

import { writable } from "svelte/store";

export const page = writable("");

export function setPageStore(newPage: string) {
	page.update(() => newPage);
}
