<script>
    import { goto } from '$app/navigation';  // This should work in newer versions

    let username = $state('');
    let password = $state('');
    let errorMessage = $state('');
    const login = () => {
        if (username == '' || password == '')
        {
            errorMessage = 'Username and Password can not be empty';
            return;
        }

        console.log(dataLogin(username, password))
    }

    const dataLogin = async (username, password) => {
        try {
            const response = await fetch('/api/auth/login-member', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    username: username,
                    password: password
                })
            });
            if (!response.ok) {
                if (response.status === 401) {
                    errorMessage = 'Invalid username or password';
                } else {
                    errorMessage = 'An error occurred. Please try again later.';
                }
                return;                
            }
            const token = await response.text();
            localStorage.setItem('jwt', token);
            goto('/product/?productid=1')
        }
        catch (ex) {
            console.log(ex)
        }
    }
</script>
<div class="login">
    <div>
        Enter Login Credentials
        <br>
    </div>
    <div>
        <input bind:value={username} placeholder='username' />
    </div>
    <div>
        <input type='password' bind:value={password} placeholder='password'/>
    </div>
    <div>
        <br>
        <button onclick={login}>LOGIN</button>
    </div>
</div>
<div>
    <div class="error-container">
        <br>
        <p class="error-message" class:visible={errorMessage}>
            {errorMessage || '\u00A0'}
        </p>
    </div>
</div>
<style>
    .login {
        display: flex;
        text-align: center;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        height: 100vh; 
    }
</style>
