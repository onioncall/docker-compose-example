<script>
	import '../app.css';
    export let data;
    console.log('Layout rendering with data:', data);
</script>

{#if data.isAuthenticated || false}
    <slot />
{:else}
    <div>Loading...</div>
{/if}
