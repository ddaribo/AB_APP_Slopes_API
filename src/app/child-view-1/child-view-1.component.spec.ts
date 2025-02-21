import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildView1Component } from './child-view-1.component';

describe('ChildView1Component', () => {
  let component: ChildView1Component;
  let fixture: ComponentFixture<ChildView1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChildView1Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChildView1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
