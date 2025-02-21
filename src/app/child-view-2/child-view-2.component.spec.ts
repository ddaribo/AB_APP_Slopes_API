import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildView2Component } from './child-view-2.component';

describe('ChildView2Component', () => {
  let component: ChildView2Component;
  let fixture: ComponentFixture<ChildView2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChildView2Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChildView2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
