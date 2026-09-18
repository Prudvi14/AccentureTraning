import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

function Login() {
    const [userName, setUserName] = useState("");
    const [password, setPassword] = useState("");
    const { login, error, loading } = useAuth();
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        const success = await login(userName, password);
        if (success) {
            navigate("/home");
        }
    };

    return (
        <div className="login-page">
            <div className="login-box">
                <h1>USER LOGIN</h1>
                <form onSubmit={handleSubmit}>
                    <div className="form-row">
                        <label htmlFor="userName">EmailId</label>
                        <input
                            id="userName"
                            type="text"
                            value={userName}
                            onChange={(e) => setUserName(e.target.value)}
                            required
                        />
                    </div>
                    <div className="form-row">
                        <label htmlFor="password">Password</label>
                        <input
                            id="password"
                            type="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            required
                        />
                    </div>
                    {error && <div className="error-text">{error}</div>}
                    <button type="submit" className="btn" disabled={loading}>
                        {loading ? "Logging in..." : "LOGIN"}
                    </button>
                </form>
            </div>
        </div>
    );
}

export default Login;