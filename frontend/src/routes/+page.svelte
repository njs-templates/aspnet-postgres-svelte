<script lang="ts">
// TODO: Delete this boilerplate.

import HelloWorld from "$lib/components/HelloWorld.svelte";
</script>

<main>
	<div class="main-content">
		<a
			href="https://vitejs.dev"
			target="_blank"
			rel="noreferrer"
		>
			<img
				src="/vite.svg"
				class="logo"
				alt="Vite logo"
			/>
		</a>
		<a
			href="https://svelte.dev/"
			target="_blank"
			rel="noreferrer"
		>
			<img
				src="/svelte.svg"
				class="logo svelte"
				alt="Svelte logo"
			/>
		</a>
		<a
			href="https://www.typescriptlang.org/"
			target="_blank"
			rel="noreferrer"
		>
			<img
				src="/typescript.svg"
				class="logo ts"
				alt="TypeScript logo"
			/>
		</a>
	</div>
	<HelloWorld msg="Vite + Svelte Kit + TypeScript" />
</main>

<style scoped>
.main-content {
	@apply flex place-content-center;
	margin: 0 auto;
}

.logo {
	height: 10em;
	padding: 1.5em;
	will-change: filter;
}

.logo:hover {
	filter: drop-shadow(0 0 2em #646cffaa);
}

.logo.svelte:hover {
	filter: drop-shadow(0 0 2em #ff3e00aa);
}

.logo.ts:hover {
	filter: drop-shadow(0 0 2em #3178c6aa);
}
</style>
