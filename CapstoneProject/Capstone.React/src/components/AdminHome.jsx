import { useEffect, useState, useCallback } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { getAllRequests, closeRequest } from "../api/apiClient";

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

function AdminHome() {
    const { user, logout } = useAuth();
    const [requests, setRequests] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const [closingId, setClosingId] = useState(null);

    const loadRequests = useCallback(async () => {
        setLoading(true);
        setError("");
        try {
            const response = await getAllRequests();
            setRequests(response.data || []);
        } catch (err) {
            if (err.response && err.response.status === 404) {
                setRequests([]);
            } else {
                setError("Unable to load service requests right now.");
            }
        } finally {
            setLoading(false);
        }
    }, []);

    useEffect(() => {
        loadRequests();
    }, [loadRequests]);

    const handleClose = async (requestId) => {
        setClosingId(requestId);
        try {
            await closeRequest(requestId);
            await loadRequests();
        } catch {
            setError("Unable to close this request. Please try again.");
        } finally {
            setClosingId(null);
        }
    };

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
                <Link to="/search">Search Requests</Link>

                {loading && <p>Loading requests...</p>}
                {error && <div className="error-text">{error}</div>}

                {!loading && (
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
                                    <td colSpan={6}>No service requests found.</td>
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
                                                {!isClosed && (
                                                    <a onClick={() => handleClose(req.requestId)}>
                                                        {closingId === req.requestId ? "Closing..." : "Close Request"}
                                                    </a>
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

export default AdminHome;