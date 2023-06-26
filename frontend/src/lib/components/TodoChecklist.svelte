<script lang="ts">
interface todoItem {
	id: number;
	label: string;
	completed: boolean;
}

const testData: todoItem[] = [
	// Note: for legal reasons, this is a joke.
	{
		id: 1,
		label: "Do stuff",
		completed: false,
	},
	{
		id: 2,
		label: "Commit war crimes",
		completed: true,
	},
	{
		id: 3,
		label: "Pay your taxes",
		completed: false,
	},
];
</script>

<main>
	<!-- <h1>wow</h1> -->
	{#each testData as item}
		<div class="flex flex-row place-content-center gap-4">
			<p class="">{item.label}</p>
			<input
				type="checkbox"
				checked={item.completed}
				class="checkbox checkbox-primary justify-end"
			/>
			<div class="justify-self-center" />
		</div>
	{/each}
</main>
