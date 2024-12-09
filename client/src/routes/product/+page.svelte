<script>
    import { onMount } from 'svelte';
    import { checkAuth, isAuthChecked } from '$lib/guards/authGuard';

	let loadingText = $state('Validating Token...');

    onMount(() => {
        checkAuth();
    });
</script>

<!-- rest of your products page code -->
{#if $isAuthChecked}
	<div class="product">
		<div>we did it gang</div>
		<br>
		<button>do thing</button>
	</div>
{:else}
	<div class="product">{loadingText}</div>
{/if}

<style>
	.product {
		display: flex;
		text-align: center;
		flex-direction: column;
		justify-content: center;
		align-items: center;
		height: 100vh; 
	}
</style>

