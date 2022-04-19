import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'origin4300';
  
  constructor(private http: HttpClient) { }

  onClick() {
    this.http.post('https://localhost:5001', {
      message: "Hello from 'Origin4300'"
    }).subscribe(console.log)
  }
}
