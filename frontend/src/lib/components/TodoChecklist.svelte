<script lang="ts">
import { onMount } from "svelte";
import axios from "axios";

interface todoItem {
	id: number;
	label: string;
	completed: boolean;
}

let data: todoItem[] = [];

const baseUrl = "http://localhost:5048/api/";
const todoUrl = baseUrl + "TodoItems/";
const debug = false;

async function getTodos() {
	try {
		const res = await axios.get(todoUrl);
		return res;
	} catch (err) {
		console.error(
			"Error. Get request was not successful. Postgres may not be running."
		);
		console.error(err);
	}
}

async function getTodoFromId(id: number) {
	const url: string = todoUrl + String(id);

	try {
		const res = await axios.get(url);

		return res.data;
	} catch (err) {
		console.error(err);
	}
}

async function updateCompleted(item: todoItem) {
	const url: string = todoUrl + String(item.id);

	try {
		const res = await axios.put(url, {
			id: item.id,
			label: item.label,
			completed: !item.completed,
		});

		return res.data.completed;
	} catch (err) {
		console.error(err);
	}
}

onMount(async () => {
	if (debug === false) {
		const response = await getTodos();

		if (response === undefined) {
			return;
		}

		if (response.status === 200) {
			console.log(response.data);
			data = response.data;
		} else {
			console.error(response);
		}
	} else {
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

		data = testData;
	}
});
</script>

<main>
	<!-- <h1>wow</h1> -->
	{#each data as item}
		<div class="flex flex-row place-content-center gap-4">
			<p class="">{item.label}</p>
			<input
				type="checkbox"
				checked={item.completed}
				on:change={updateCompleted(item)}
				class="checkbox checkbox-primary justify-end"
			/>
			<div class="justify-self-center" />
		</div>
	{/each}
</main>
