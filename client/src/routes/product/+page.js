export const load = async ({ fetch, url, parent }) => {
    // Wait for the parent layout data
    const layoutData = await parent();
    
    const productId = url.searchParams.get('productid');
    
    if (!productId) {
        return {
            product: null,
            error: 'No ID provided'
        };
    }

    try {
        const response = await fetch(`http://localhost:8080/api/product/?productid=${productId}`);
        if (!response.ok) {
            throw new Error('Failed to fetch data');
        }
        const product = await response.json();
        
        return {
            product,
            error: null
        };
    } catch (error) {
        return {
            product: null,
            error: error.message
        };
    }
};
