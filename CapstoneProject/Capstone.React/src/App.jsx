import { Routes, Route, Navigate } from "react-router-dom";
import { useAuth } from "./context/AuthContext";
import Login from "./components/Login";
import Home from "./components/Home";
import RaiseRequest from "./components/RaiseRequest";
import DeleteRequest from "./components/DeleteRequest";
import ReOpenRequest from "./components/ReOpenRequest";
import SearchRequests from "./components/SearchRequests";

function RequireAuth({ children }) {
    const { user } = useAuth();
    if (!user) {
        return <Navigate to="/" replace />;
    }
    return children;
}

function App() {
    return (
        <Routes>
            <Route path="/" element={<Login />} />

            <Route
                path="/home"
                element={
                    <RequireAuth>
                        <Home />
                    </RequireAuth>
                }
            />

            <Route
                path="/raise"
                element={
                    <RequireAuth>
                        <RaiseRequest />
                    </RequireAuth>
                }
            />

            <Route
                path="/delete/:id"
                element={
                    <RequireAuth>
                        <DeleteRequest />
                    </RequireAuth>
                }
            />

            <Route
                path="/reopen/:id"
                element={
                    <RequireAuth>
                        <ReOpenRequest />
                    </RequireAuth>
                }
            />

            <Route
                path="/search"
                element={
                    <RequireAuth>
                        <SearchRequests />
                    </RequireAuth>
                }
            />

            <Route path="*" element={<Navigate to="/" replace />} />
        </Routes>
    );
}

export default App;