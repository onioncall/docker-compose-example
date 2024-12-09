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
	
/**
* Authenticates user and handles login process
* @param {string} username - The username or email for login
* @param {string} password - The user's password
* @returns {Promise<void>} Nothing is returned, but will:
*  - Store JWT token in sessionStorage if successful
*  - Set error messages for invalid credentials or server errors
*  - Redirect to product page on success
* @throws {Error} Logs any exceptions to console
*/
	const dataLogin = async (username, password) => {
		try {
			const response = await fetch('http://localhost:8082/api/auth/login-member', {
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
			console.log('JWT Token:', token);
			sessionStorage.setItem('jwt', token);

			goto('/product')
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
