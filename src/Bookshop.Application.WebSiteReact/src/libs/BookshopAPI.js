import appConfig from "../appConfig";
import axios from "axios";

export async function getAllBooks() {
    return (await axios.get(`${appConfig.apiConnection.url}/books`)).data;
}

export async function getSingleBook(isbn) {
    return (await axios.get(`${{appConfig.apiConnection.url}/books/{isbn}}`)).data;
}

export async function createBook(book) {
    return axios.post(`${appConfig.apiConnection.url}/books`, book);
}

export async function updateBook(book) {
    return axios.put(`${appConfig.apiConnection.url}/books`, book);
}
