import { Navigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import UserHome from "./UserHome";
import AdminHome from "./AdminHome";

function Home() {
    const { user, isAdmin } = useAuth();

    if (!user) {
        return <Navigate to="/" replace />;
    }

    return isAdmin ? <AdminHome /> : <UserHome />;
}

export default Home;