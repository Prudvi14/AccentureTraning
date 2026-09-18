import { createContext, useContext, useState } from "react";
import { authenticate } from "../api/apiClient";

const AuthContext = createContext(null);

export function AuthProvider({ children }) {
    const [user, setUser] = useState(null);
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);

    const login = async (userName, password) => {
        setLoading(true);
        setError("");
        try {
            const response = await authenticate(userName, password);
            setUser(response.data);
            return true;
        } catch (err) {
            setUser(null);
            if (err.response && err.response.status === 404) {
                setError("Invalid username or password.");
            } else {
                setError("Something went wrong while logging in. Please try again.");
            }
            return false;
        } finally {
            setLoading(false);
        }
    };

    const logout = () => {
        setUser(null);
        setError("");
    };

    const isAdmin = user?.role?.roleName === "Admin";

    return (
        <AuthContext.Provider value={{ user, login, logout, error, loading, isAdmin }}>
            {children}
        </AuthContext.Provider>
    );
}

// eslint-disable-next-line react-refresh/only-export-components 
export function useAuth() {
    const context = useContext(AuthContext);
    if (!context) {
        throw new Error("useAuth must be used within an AuthProvider");
    }
    return context;
}