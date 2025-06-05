import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';

const LoginPage = () => {
    const navigate = useNavigate();
    const [identifier, setIdentifier] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');

    useEffect(() => {
        document.body.style.backgroundImage = `url(${woodBackground})`;
        document.body.style.backgroundSize = 'cover';
        document.body.style.backgroundPosition = 'center';
        document.body.style.backgroundRepeat = 'no-repeat';
        document.body.style.backgroundAttachment = 'fixed';
        document.body.style.minHeight = '100vh';
        return () => {
            document.body.style.backgroundImage = 'none';
            document.body.style.backgroundSize = '';
            document.body.style.backgroundPosition = '';
            document.body.style.backgroundRepeat = '';
            document.body.style.backgroundAttachment = '';
            document.body.style.minHeight = '';
        };
    }, []);

    const handleLogin = async (e) => {
        e.preventDefault();
        setError('');

        try {
            const response = await fetch('https://localhost:7174/api/auth/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ identifier, password }),
            });

            if (response.ok) {
                const userData = await response.json(); // Should include at least login and email

                // Save user data in sessionStorage
                sessionStorage.setItem('currentUser', JSON.stringify(userData));

                console.log("Login successful!", userData);
                alert("Login successful!");

                navigate('/profile');
            } else {
                const errorData = await response.json();
                setError(errorData.message || "Login failed. Please check your credentials.");
                console.error('Login error:', errorData);
            }
        } catch (err) {
            setError("An unexpected error occurred. Please try again later.");
            console.error('Network error during login:', err);
        }
    };

    return (
        <main className="auth-page">
            <div className="auth-form-container">
                <h2>Login</h2>
                <form className="auth-form" onSubmit={handleLogin}>
                    {error && <p className="error-message" style={{ color: 'red', marginBottom: '15px' }}>{error}</p>}
                    <div className="form-group">
                        <label htmlFor="identifier">Username or E-mail:</label>
                        <input
                            type="text"
                            id="identifier"
                            className="form-input"
                            value={identifier}
                            onChange={(e) => setIdentifier(e.target.value)}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Password:</label>
                        <input
                            type="password"
                            id="password"
                            className="form-input"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            required
                        />
                    </div>
                    <button type="submit" className="auth-button">Log In</button>
                </form>
                <p className="auth-switch-link">
                    Don't have an account? <Link to="/register">Register</Link>
                </p>
            </div>
        </main>
    );
};

export default LoginPage;