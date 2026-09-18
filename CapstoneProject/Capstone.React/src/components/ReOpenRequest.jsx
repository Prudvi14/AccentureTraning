import { useEffect, useState } from "react";
import { Link, useParams, useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { getRequestById, reopenRequest } from "../api/apiClient";

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

function ReOpenRequest() {
    const { id } = useParams();
    const { user, logout } = useAuth();
    const navigate = useNavigate();

    const [request, setRequest] = useState(null);
    const [justification, setJustification] = useState("");
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const [submitting, setSubmitting] = useState(false);

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

    const handleReOpen = async (e) => {
        e.preventDefault();
        if (!justification.trim()) {
            setError("Justification is required to re-open a request.");
            return;
        }

        setError("");
        setSubmitting(true);
        try {
            const payload = {
                ...request,
                justification,
            };
            await reopenRequest(payload);
            navigate("/home");
        } catch {
            setError("Unable to re-open this request. Please try again.");
            setSubmitting(false);
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
                <h4>Re-Open Request</h4>

                {loading && <p>Loading...</p>}

                {!loading && request && (
                    <form onSubmit={handleReOpen} className="detail-box">
                        <table className="detail-table">
                            <tbody>
                                <tr>
                                    <td>Description</td>
                                    <td>{request.description}</td>
                                </tr>
                                <tr>
                                    <td>Details</td>
                                    <td>{request.details}</td>
                                </tr>
                                <tr>
                                    <td>Creation Date</td>
                                    <td>{formatDate(request.raisedOn)}</td>
                                </tr>
                                <tr>
                                    <td>Justification</td>
                                    <td>
                                        <textarea
                                            value={justification}
                                            onChange={(e) => setJustification(e.target.value)}
                                            maxLength={50}
                                            rows={2}
                                            style={{ width: "100%" }}
                                            required
                                        />
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                        {error && <div className="error-text">{error}</div>}

                        <button type="submit" className="btn" disabled={submitting}>
                            {submitting ? "Re-Opening..." : "ReOpen Request"}
                        </button>
                    </form>
                )}

                <div style={{ marginTop: 16 }}>
                    <Link to="/home">Back to List</Link>
                </div>
            </div>
        </div>
    );
}

export default ReOpenRequest;