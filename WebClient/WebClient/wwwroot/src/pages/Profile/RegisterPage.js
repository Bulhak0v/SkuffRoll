import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';

const RegisterPage = () => {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [error, setError] = useState(''); // State for displaying error messages

    useEffect(() => {
        document.body.style.backgroundImage = `url(${woodBackground})`;
        // Clean up background style when component unmounts
        return () => {
            document.body.style.backgroundImage = 'none';
        };
    }, []);

    const handleRegister = async (e) => {
        e.preventDefault();
        setError(''); // Clear previous errors

        if (password !== confirmPassword) {
            setError("Passwords do not match!");
            return;
        }

        try {
            const response = await fetch('api/auth/register', { // Assuming your registration endpoint is /api/auth/register
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email, login: username, password }), // Ensure 'login' matches backend model
            });

            if (response.ok) {
                alert("Registration successful! You can now log in.");
                navigate('/login'); // Redirect to login page on success
            } else {
                const errorData = await response.json();
                setError(errorData.message || "Registration failed. Please try again.");
                console.error('Registration error:', errorData);
            }
        } catch (err) {
            setError("An unexpected error occurred. Please try again later.");
            console.error('Network error during registration:', err);
        }
    };

    return (
        <main className="auth-page">
            <div className="auth-form-container">
                <h2>Register</h2>
                <form className="auth-form" onSubmit={handleRegister}>
                    {error && <p className="error-message" style={{ color: 'red' }}>{error}</p>} {/* Display error message */}
                    <div className="form-group">
                        <label htmlFor="email">E-mail:</label>
                        <input type="email" id="email" className="form-input" value={email} onChange={(e) => setEmail(e.target.value)} required />
                    </div>
                    <div className="form-group">
                        <label htmlFor="username">Username:</label>
                        <input type="text" id="username" className="form-input" value={username} onChange={(e) => setUsername(e.target.value)} required />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Password:</label>
                        <input type="password" id="password" className="form-input" value={password} onChange={(e) => setPassword(e.target.value)} required />
                    </div>
                    <div className="form-group">
                        <label htmlFor="confirmPassword">Confirm Password:</label>
                        <input type="password" id="confirmPassword" className="form-input" value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} required />
                    </div>
                    <button type="submit" className="auth-button">Register</button>
                </form>
                <p className="auth-switch-link">
                    Already have an account? <Link to="/login">Log in</Link>
                </p>
            </div>
        </main>
    );
};

export default RegisterPage;