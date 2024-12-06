<script>
	let username = $state('');
	let password = $state('');

	function login() {
		if (username == '' || password == '')
		{
			console.error('Username and Password can not be empty');
			return;
		}
		
		console.log(dataLogin(username, password))
	}

	async function dataLogin(username, password) {
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
				throw new Error(`HTTP error! status: ${response.status}`);
			}

			const data = await response.json();
			return data;
		} catch (error) {
			console.error('login failed: ', error)	
		}	
	}
</script>

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
