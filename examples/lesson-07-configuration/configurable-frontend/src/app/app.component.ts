import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { AppShell, ThemeService } from './theme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'configurable-frontend';

  result: Observable<AppShell>

  constructor(private themeService: ThemeService) {
    this.result = this.themeService.getTheme()
  }
}
