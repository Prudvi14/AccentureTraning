import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { getRequestById, deleteRequest } from "../api/apiClient";

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

function DeleteRequest() {
    const { id } = useParams();
    const { user, logout } = useAuth();
    const [request, setRequest] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const [statusMessage, setStatusMessage] = useState("");
    const [deleted, setDeleted] = useState(false);

    useEffect(() => {
        let isMounted = true;

        const loadRequest = async () => {
            setLoading(true);
            try {
                const response = await getRequestById(id);
                if (isMounted) {
                    setRequest(response.data);
                }
            } catch {
                if (isMounted) {
                    setError("Unable to load this request.");
                }
            } finally {
                if (isMounted) {
                    setLoading(false);
                }
            }
        };

        loadRequest();

        return () => {
            isMounted = false;
        };
    }, [id]);

    const handleDelete = async () => {
        setError("");
        try {
            await deleteRequest(id);
            setStatusMessage("Request deleted successfully.");
            setDeleted(true);
        } catch {
            setError("Unable to delete this request. It may have already been removed.");
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
                <h4>Are you sure you want to delete this?</h4>

                {loading && <p>Loading...</p>}
                {error && <div className="error-text">{error}</div>}

                {!loading && request && (
                    <div className="detail-box">
                        <table className="detail-table detail-table-horizontal">
                            <thead>
                                <tr>
                                    <th>Description</th>
                                    <th>Details</th>
                                    <th>Creation Date</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>{request.description}</td>
                                    <td>{request.details}</td>
                                    <td>{formatDate(request.raisedOn)}</td>
                                </tr>
                            </tbody>
                        </table>

                        <button
                            type="button"
                            className="btn"
                            onClick={handleDelete}
                            disabled={deleted}
                        >
                            Delete Request
                        </button>

                        {statusMessage && <div className="success-text">{statusMessage}</div>}
                    </div>
                )}

                <div style={{ marginTop: 16 }}>
                    <Link to="/home">Back to List</Link>
                </div>
            </div>
        </div>
    );
}

export default DeleteRequest;