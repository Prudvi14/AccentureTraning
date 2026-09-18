import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { getRequestsByUserName } from "../api/apiClient";

function formatDate(dateString) {
    const date = new Date(dateString);
    return date.toLocaleString("en-US", {
        month: "numeric",
        day: "numeric",
        year: "numeric",
        hour: "numeric",
        minute: "2-digit",
        hour12: true,
    });
}

function UserHome() {
    const { user, logout } = useAuth();
    const [requests, setRequests] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        let isMounted = true;

        const loadRequests = async () => {
            setLoading(true);
            setError("");
            try {
                const response = await getRequestsByUserName(user.userName);
                if (isMounted) {
                    setRequests(response.data || []);
                }
            } catch {
                if (isMounted) {
                    setError("Unable to load your service requests right now.");
                }
            } finally {
                if (isMounted) {
                    setLoading(false);
                }
            }
        };

        if (user) {
            loadRequests();
        }

        return () => {
            isMounted = false;
        };
    }, [user]);

    return (
        <div className="app-shell">
            <div className="top-banner">
                <span className="logout-link" onClick={logout}>
                    Logout
                </span>
                <h2>Your One Stop Web Site For All Service Requests!</h2>
            </div>

            <div className="page-content">
                <h3>Welcome {user?.userName}</h3>
                <Link to="/raise">Raise New Request</Link>

                {loading && <p>Loading your requests...</p>}
                {error && <div className="error-text">{error}</div>}

                {!loading && !error && (
                    <table className="requests-table">
                        <thead>
                            <tr>
                                <th>Request ID</th>
                                <th>Description</th>
                                <th>Requested By</th>
                                <th>Creation Date</th>
                                <th>Request Status</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {requests.length === 0 ? (
                                <tr>
                                    <td colSpan={6}>You have not raised any requests yet.</td>
                                </tr>
                            ) : (
                                requests.map((req) => {
                                    const statusName = req.status?.description || "New";
                                    const isClosed = statusName === "Closed";
                                    return (
                                        <tr key={req.requestId}>
                                            <td>{req.requestId}</td>
                                            <td>{req.description}</td>
                                            <td>{req.raisedBy}</td>
                                            <td>{formatDate(req.raisedOn)}</td>
                                            <td>{statusName}</td>
                                            <td>
                                                {isClosed ? (
                                                    <Link to={`/reopen/${req.requestId}`}>Re-Open</Link>
                                                ) : (
                                                    <Link to={`/delete/${req.requestId}`}>Delete</Link>
                                                )}
                                            </td>
                                        </tr>
                                    );
                                })
                            )}
                        </tbody>
                    </table>
                )}

                <div className="footer-note">Copyright © 2025 Accenture. All rights reserved.</div>
            </div>
        </div>
    );
}

export default UserHome;