import axios from "axios";

const API_BASE_URL = "https://localhost:5193/api/ITSRPAPI";

const apiClient = axios.create({
    baseURL: API_BASE_URL,
    headers: {
        "Content-Type": "application/json",
    },
});

export const authenticate = (userName, password) =>
    apiClient.get("/Authenticate", { params: { userName, password } });

export const getUser = (userName) =>
    apiClient.get("/GetUser", { params: { userName } });

export const getAllRequests = () => apiClient.get("/GetAllRequest");

export const getRequestsByUserName = (userName) =>
    apiClient.get("/GetRequestByuserName", { params: { userName } });

export const getRequestById = (reqId) =>
    apiClient.get("/GetRequestById", { params: { reqId } });

export const createRequest = (newRequest) =>
    apiClient.post("/CreateNewSerRequest", newRequest);

export const reopenRequest = (request) =>
    apiClient.post("/reopen", request);

export const closeRequest = (id) =>
    apiClient.get("/CloseRequest", { params: { id } });

export const deleteRequest = (id) =>
    apiClient.get("/Delete", { params: { id } });

export default apiClient;