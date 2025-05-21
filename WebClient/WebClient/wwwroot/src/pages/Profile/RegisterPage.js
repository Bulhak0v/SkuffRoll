import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import woodBackground from '../../assets/images/general/wood-texture.jpg';

const RegisterPage = () => {
  const navigate = useNavigate();
  const [email, setEmail] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');

  useEffect(() => {
    document.body.style.backgroundImage = `url(${woodBackground})`;
  }, []);

  const handleRegister = (e) => {
    e.preventDefault();
    if (password !== confirmPassword) {
      alert("Passwords do not match!");
      return;
    }
    alert(`Attempting registration for: ${username} with email: ${email}. (Backend not implemented)`);
  };

  return (
    <main className="auth-page">
      <div className="auth-form-container">
        <h2>Register</h2>
        <form className="auth-form" onSubmit={handleRegister}>
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