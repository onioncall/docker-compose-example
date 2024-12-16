<script>
    import { page } from '$app/stores';
    export let data;

    $: productId = $page.url.searchParams.get('productid');
 	$: quantity = data.product?.quantity ?? 0;

	
    const updateQuantity = async (quantity, productId) => {
        try {
			const token = localStorage.getItem('jwt');
            const response = await fetch('/api/product/update-product-quantity', {
                method: 'PUT',
                headers: {
                	'Authorization': `Bearer ${token}`,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    quantity: quantity,
                    productId: productId
                })
            });

			console.log(JSON.stringify({
                    quantity: quantity,
                    productId: productId
                }))

            if (!response.ok) {
				console.log('invalid item')

                return false;                
            }

			return true
        }
        catch (ex) {
            console.log(ex)
        }
    }

    const handleQuantityUpdate = async () => {
        const success = await updateQuantity(quantity, productId);
        if (success) {
            window.location.reload();
        }
    }
</script>

<div class="product">
	<button onclick={handleQuantityUpdate}>Update Quantity</button>
	<br>
	<div>
		<input bind:value={quantity} />
	</div>
</div>

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
