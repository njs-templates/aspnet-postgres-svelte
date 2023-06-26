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
		<p>id: {item.id}</p>
		<p>label: {item.label}</p>
		<p>completed: {item.completed}</p>
	{/each}
</main>
