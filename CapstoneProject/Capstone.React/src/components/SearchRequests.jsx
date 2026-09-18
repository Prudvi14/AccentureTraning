import { useState } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { getRequestsByUserName, closeRequest } from "../api/apiClient";

function formatDate(dateString) {
    if (!dateString) return "";
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

function SearchRequests() {
    const { user, logout } = useAuth();
    const [requesterName, setRequesterName] = useState("");
    const [requests, setRequests] = useState([]);
    const [searched, setSearched] = useState(false);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState("");
    const [closingId, setClosingId] = useState(null);

    const runSearch = async () => {
        setLoading(true);
        setError("");
        setSearched(true);
        try {
            const response = await getRequestsByUserName(requesterName);
            setRequests(response.data || []);
        } catch {
            setRequests([]);
            setError("Unable to search requests right now.");
        } finally {
            setLoading(false);
        }
    };

    const handleSearch = (e) => {
        e.preventDefault();
        runSearch();
    };

    const handleClose = async (requestId) => {
        setClosingId(requestId);
        try {
            await closeRequest(requestId);
            await runSearch();
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
                <h4>Search Requests</h4>

                <form onSubmit={handleSearch}>
                    <div className="form-row" style={{ maxWidth: 420 }}>
                        <label htmlFor="requesterName">Enter the Requester Name:</label>
                        <input
                            id="requesterName"
                            type="text"
                            value={requesterName}
                            onChange={(e) => setRequesterName(e.target.value)}
                        />
                    </div>
                    <button type="submit" className="btn" disabled={loading}>
                        {loading ? "Searching..." : "Search"}
                    </button>
                </form>

                {error && <div className="error-text">{error}</div>}

                {searched && !loading && requests.length === 0 && !error && (
                    <p style={{ marginTop: 16 }}>No matching requests found.</p>
                )}

                {searched && !loading && requests.length > 0 && (
                    <table className="requests-table">
                        <thead>
                            <tr>
                                <th>Request ID</th>
                                <th>Description</th>
                                <th>Details</th>
                                <th>Requested By</th>
                                <th>Creation Date</th>
                                <th>Request Status</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {requests.map((req) => {
                                const statusName = req.status?.description || "New";
                                const isClosed = statusName === "Closed";
                                return (
                                    <tr key={req.requestId}>
                                        <td>{req.requestId}</td>
                                        <td>{req.description}</td>
                                        <td>{req.details}</td>
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
                            })}
                        </tbody>
                    </table>
                )}

                <div style={{ marginTop: 16 }}>
                    <Link to="/home">Back to List</Link>
                </div>
            </div>
        </div>
    );
}

export default SearchRequests;