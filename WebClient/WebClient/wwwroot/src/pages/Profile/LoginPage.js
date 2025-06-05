// src/components/LoginPage.js
import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';

const LoginPage = () => {
    const navigate = useNavigate();
    const [identifier, setIdentifier] = useState(''); // Use 'identifier' to match backend 'LoginRequest'
    const [password, setPassword] = useState('');
    const [error, setError] = useState(''); // State to hold login error messages

    useEffect(() => {
        document.body.style.backgroundImage = `url(${woodBackground})`;
        document.body.style.backgroundSize = 'cover';
        document.body.style.backgroundPosition = 'center';
        document.body.style.backgroundRepeat = 'no-repeat';
        document.body.style.backgroundAttachment = 'fixed';
        document.body.style.minHeight = '100vh';
        return () => {
            // Clean up body styles when component unmounts (e.g., navigating away)
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
        setError(''); // Clear any previous errors

        try {
            // Send login request to your ASP.NET Core backend
            const response = await fetch('/api/auth/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ identifier, password }), // Ensure keys match backend's LoginRequest model
            });

            if (response.ok) {
                const data = await response.json();
                // Assuming your backend returns { token: "...", message: "..." }
                const token = data.token;

                // Store the JWT token securely (localStorage is common for simpler apps, but consider HttpOnly cookies for more security)
                localStorage.setItem('authToken', token);

                console.log("Login successful! Token stored:", token);
                alert("Login successful!"); // User feedback

                // Redirect to a protected page, e.g., the UserProfilePage or dashboard
                navigate('/user-profile'); // Assuming /user-profile is the route for UserProfilePage
            } else {
                // Handle API errors (e.g., 401 Unauthorized, 400 Bad Request)
                const errorData = await response.json();
                setError(errorData.message || "Login failed. Please check your credentials.");
                console.error('Login error:', errorData);
            }
        } catch (err) {
            // Handle network errors (e.g., server unreachable)
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