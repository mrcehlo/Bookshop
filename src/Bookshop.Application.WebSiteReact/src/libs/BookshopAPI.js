import {apiConnection} from "../appConfig";
import axios from "axios";

export async function getAllBooks() {
    return (await axios.get(`${apiConnection.url}/books`)).data;
}

export async function createBook(book) {
    return axios.post(`${apiConnection.url}/books`, book);
}

export async function updateBook(book) {
    return axios.put(`${apiConnection.url}/books`, book);
}
