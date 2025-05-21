import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';

const LoginPage = () => {
  const navigate = useNavigate();
  const [emailOrUsername, setEmailOrUsername] = useState('');
  const [password, setPassword] = useState('');

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
    // ... (rest of background styles)
  }, []);

  const handleLogin = (e) => {
    e.preventDefault();
    // Mock login - no actual validation or auth
    alert(`Attempting login with: ${emailOrUsername} and password: ${password}. (Backend not implemented)`);
    // In a real app, after successful login, you'd redirect to profile or dashboard
    // For now, let's simulate going to profile as John_Doe is always "logged in"
    // navigate('/profile'); // Or keep user on login page after alert for demo
  };

  return (
    <main className="auth-page">
      <div className="auth-form-container">
        <h2>Login</h2>
        <form className="auth-form" onSubmit={handleLogin}>
          <div className="form-group">
            <label htmlFor="emailOrUsername">Username or E-mail:</label>
            <input
              type="text"
              id="emailOrUsername"
              className="form-input"
              value={emailOrUsername}
              onChange={(e) => setEmailOrUsername(e.target.value)}
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