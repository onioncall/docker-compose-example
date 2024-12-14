export const ssr = false;  // Disable server-side rendering since we're using client-side auth

export const load = async ({ url }) => {
    // Skip check for public routes
    if (url.pathname === '/login') {
        return { isAuthenticated: true };
    }

    const token = sessionStorage?.getItem('jwt');
    if (!token) {
        throw redirect(307, '/login');
    }

    try {
        const response = await fetch('http://localhost:8082/api/auth/verify-token', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        
        if (!response.ok) {
            sessionStorage.removeItem('jwt');
            throw redirect(307, '/login');
        }
        
        return { isAuthenticated: true };
    } catch (error) {
        sessionStorage?.removeItem('jwt');
        throw redirect(307, '/login');
    }
};
