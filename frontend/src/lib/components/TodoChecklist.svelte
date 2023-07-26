<script lang="ts">
import { onMount } from "svelte";
import axios from "axios";

interface todoItem {
	id: number;
	label: string;
	completed: boolean;
}

let textInput: string;
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

async function newTodo(label: string) {
	if (label === "" || label === undefined) {
		label = "Todo";
	}

	console.log(label);

	try {
		const data = { label: label, completed: false };
		await axios.post(todoUrl, data);
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

async function onAddClick() {
	await newTodo(textInput);
	refreshData();
}

async function onDeleteClick(id: number) {
	await deleteTodo(id);
	refreshData();
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
		<div class="flex flex-row gap-2">
			<input
				bind:value={textInput}
				type="text"
				placeholder="Label"
				class="input input-bordered input-primary input-sm w-full max-w-xs"
			/>
			<btn
				tabindex="0"
				role="button"
				class="btn btn-sm btn-primary"
				on:click={async () => await onAddClick()}
				on:keypress={async () => await onAddClick()}>Add</btn
			>
		</div>
		{#each data as item}
			<div class="flex flex-row place-content-center gap-2">
				<p class="">{item.label}</p>
				<input
					type="checkbox"
					checked={item.completed}
					on:change={async () => await updateCompleted(item)}
					class="checkbox checkbox-primary justify-end"
				/>
				<btn
					tabindex="0"
					role="button"
					class="btn btn-sm btn-error"
					on:click={async () => await onDeleteClick(item.id)}
					on:keypress={async () => await onDeleteClick(item.id)}
					>Delete</btn
				>
				<div class="justify-self-center" />
			</div>
		{/each}
	</div>
</main>
