// src/hooks.client.js
import { redirect } from '@sveltejs/kit';

export const handle = async ({ event }) => {
    // Skip auth check for login page and public routes
    if (event.url.pathname === '/login') {
        return;
    }

    const token = sessionStorage.getItem('jwt');
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
    } catch (error) {
        sessionStorage.removeItem('jwt');
        throw redirect(307, '/login');
    }
};
