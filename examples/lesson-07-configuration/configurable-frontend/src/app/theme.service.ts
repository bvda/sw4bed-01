import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  API_URL = 'https://localhost:7001/theme'

  constructor(private httpClient: HttpClient) { }

  getTheme(): Observable<Colors> {
    return this.httpClient.get<Colors>(this.API_URL)
  }
}

export interface Colors {
  colors: {
    primary: string;
    primaryLight: string;
    primaryDark: string;
    secondary: string;
    secondaryLight: string;
    secondaryDark: string;
  }
}
