import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-Nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.scss']
})
export class NavComponent implements OnInit {
  isCollapsed = true;
  constructor(private router: Router) { }

  ngOnInit() : void {
  }

  showMenu() : boolean {
    return this.router.url != '/user/login';
  }
}
