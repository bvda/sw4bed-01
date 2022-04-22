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

  onClick4200() {
    this.onClick('origin4200', `Hello from 'origin4200'`).subscribe(console.log)
  }
  
  onClick4300() {
    this.onClick('origin4300', `Hello from 'origin4300'`).subscribe(console.log)
  }  

  onClickBoth() {
    this.onClick( 'both', `Hello from 'both'`).subscribe(console.log)    
  }

  onClick(path: string, content: string = '') {
    return this.http.post(`https://localhost:5001/weatherforecast/${path}`, {
      content
    })
  }
}
