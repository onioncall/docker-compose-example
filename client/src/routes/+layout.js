import { browser } from '$app/environment';
import { redirect } from '@sveltejs/kit';

export const ssr = false;

export const load = async ({ url }) => {
    console.log('Layout load running', { browser, path: url.pathname });

    if (!browser) {
        console.log('Not in browser');
        return { isAuthenticated: false };
    }

    // Skip check for public routes
    if (url.pathname === '/login') {
        console.log('On login page');
        return { isAuthenticated: true };
    }

    try {
        const token = sessionStorage.getItem('jwt');
        
        if (token == null) {
            throw redirect(307, '/login');
        }

        const response = await fetch('http://localhost:8082/api/auth/verify-token', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        
        if (!response.ok) {
            sessionStorage.removeItem('jwt');
            throw redirect(307, '/login');
        }
        
        console.log('Auth successful');
        return { isAuthenticated: true };
    } catch (error) {
        console.error('Auth error:', error);
        sessionStorage.removeItem('jwt');
        throw redirect(307, '/login');
    }
};
