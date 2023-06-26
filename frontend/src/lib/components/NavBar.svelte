<script lang="ts">
import NavLink from "$lib/components/NavLink.svelte";

// Define href's here
const homeHref = "/";
const aboutHref = "/about";
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
		label="About"
		href={aboutHref}
	/>
</div>
