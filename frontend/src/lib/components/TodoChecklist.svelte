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
		await axios.put(url, {
			id: item.id,
			label: item.label,
			completed: !item.completed,
		});
	} catch (err) {
		console.error(err);
	}
}

async function deleteTodo(id: number) {
	const url: string = todoUrl + String(id);

	try {
		await axios.delete(url);
	} catch (err) {
		console.error(err);
	}
}

async function refreshData() {
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
}

onMount(async () => {
	if (debug === false) {
		refreshData();
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
	<div class="flex flex-col gap-2">
		{#each data as item}
			<div class="flex flex-row place-content-center gap-2">
				<p class="">{item.label}</p>
				<input
					type="checkbox"
					checked={item.completed}
					on:change={updateCompleted(item)}
					class="checkbox checkbox-primary justify-end"
				/>
				<btn
					class="btn btn-sm btn-error"
					on:click={async () => {
						await deleteTodo(item.id);
						refreshData();
					}}>Delete</btn
				>
				<div class="justify-self-center" />
			</div>
		{/each}
	</div>
</main>
