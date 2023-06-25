<script lang="ts">
import { page, setPageStore } from "$lib/stores/pageStore";

let currentPage: string;
page.subscribe((value) => {
	currentPage = value;
});

export let href: string;
export let label: string;
</script>

<a
	{href}
	on:click={() => {
		setPageStore(href);
		console.log(currentPage);
	}}
	class={currentPage === href
		? "tab tab-bordered tab-active"
		: "tab tab-bordered"}>{label}</a
>
