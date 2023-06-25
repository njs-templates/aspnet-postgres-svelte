<script lang="ts">
import NavLink from "$lib/components/NavLink.svelte";

// Define href's here
const homeHref = "/";
const otherHref = "/other";
</script>

<div
	id="nav"
	class="tabs justify-center pb-6"
>
	<NavLink
		label="Home"
		href={homeHref}
	/>
	<NavLink
		label="Other page"
		href={otherHref}
	/>
</div>
