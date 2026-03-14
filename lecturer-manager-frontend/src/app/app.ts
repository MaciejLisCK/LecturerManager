import { Component, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WeatherService } from './services/weather.service';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, JsonPipe],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  protected readonly title = signal('lecturer-manager-frontend');

  weatherForecast = signal<any>(null);

  constructor(private weatherService: WeatherService) {}

  ngOnInit() {
    this.weatherService.getWeatherForecast().subscribe(
      (data) => this.weatherForecast.set(data),
      (error) => console.error('API error:', error)
    );
  }
}
