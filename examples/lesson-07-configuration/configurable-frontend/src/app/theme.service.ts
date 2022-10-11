import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  API_URL = 'https://localhost:7001/theme'

  constructor(private httpClient: HttpClient) { }

  getTheme(): Observable<AppShell> {
    return this.httpClient.get<AppShell>(this.API_URL)
  }
}

export interface AppShell { 
  colors: Colors;
  fonts: Fonts;
}

export interface Colors {
    primary: string;
    primaryLight: string;
    primaryDark: string;
    secondary: string;
    secondaryLight: string;
    secondaryDark: string;
}

export interface Fonts {
  display: Font;
  body: Font;
}

export interface Font {
  name: string;
  size: number;
  color: string;
}
