import { browser } from '$app/environment';
import { goto } from '$app/navigation';
import { writable } from 'svelte/store';

export const isAuthChecked = writable(false);

export const checkAuth = async () => {
    if (!browser) return;

    const token = sessionStorage.getItem('jwt'); // or however you store your token
    
    if (!token) {
        goto('/login');
        return;
    }

    try {
        const response = await fetch('http://localhost:8082/api/auth/verify-token', {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        
        if (!response.ok) {
            sessionStorage.removeItem('jwt');
            goto('/login');
        }
    } catch (error) {
        sessionStorage.removeItem('jwt');
        goto('/login');
    } finally {
        isAuthChecked.set(true);
    }
}
