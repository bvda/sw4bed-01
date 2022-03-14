import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Colors, ThemeService } from './theme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'configurable-frontend';

  result: Observable<Colors>

  constructor(private themeService: ThemeService) {
    this.result = this.themeService.getTheme()
  }
}
