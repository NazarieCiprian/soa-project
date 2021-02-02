import { getBaseUrl } from "../../main";

export class ApiUrls{
    static readonly baseUrl = 'https://localhost:5876/'
    static readonly getFreights = ApiUrls.baseUrl+'rest/Freight/getavailablefreights';
    static readonly takeFreight = ApiUrls.baseUrl+'rest/Trucker/takefreight';
    static readonly addFreight = ApiUrls.baseUrl+'rest/Freight/addfreight';
    static readonly authenticate = ApiUrls.baseUrl + 'rest/Authentication/authenticate';
    static readonly addTrucker = ApiUrls.baseUrl+'rest/Trucker/addtrucker';
    static readonly getTruckerFreights = ApiUrls.baseUrl+'rest/Trucker/gettruckerfreights';
}