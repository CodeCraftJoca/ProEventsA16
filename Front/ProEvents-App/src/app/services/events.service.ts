import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Events } from "../models/Events";

@Injectable(
    //{providedIn: 'root'}
)

export class EventsService{
    baseUrl = 'https://localhost:5223/api/Event';

    constructor(private http: HttpClient){}

    public getEvents() : Observable<Events[]>{
        return this.http.get<Events[]>(this.baseUrl);
    }
    public getEventsByTheme(theme: string) : Observable<Events[]>{
        return this.http.get<Events[]>(`${this.baseUrl}/${theme}/theme`);
    }
    public getEventById(id: number) : Observable<Events>{
        return this.http.get<Events>(`${this.baseUrl}/${id}`);
    }
   
}